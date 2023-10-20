using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using EmployeeTimesheets.DAO;
using EmployeeTimesheets.Models;

namespace EmployeeTimesheets.Tests.DAO
{
    [TestClass]
    public class TimesheetSqlDaoTests : BaseDaoTests
    {
        private static readonly Timesheet TIMESHEET_1 = new Timesheet(1, 1, 1, DateTime.Parse("2021-01-01"), 1.0M, true, "Timesheet 1");
        private static readonly Timesheet TIMESHEET_2 = new Timesheet(2, 1, 1, DateTime.Parse("2021-01-02"), 1.5M, true, "Timesheet 2");
        private static readonly Timesheet TIMESHEET_3 = new Timesheet(3, 2, 1, DateTime.Parse("2021-01-01"), 0.25M, true, "Timesheet 3");
        private static readonly Timesheet TIMESHEET_4 = new Timesheet(4, 2, 2, DateTime.Parse("2021-02-01"), 2.0M, false, "Timesheet 4");

        private Timesheet testTimesheet;
        private TimesheetSqlDao dao;


        [TestInitialize]
        public override void Setup()
        {
            dao = new TimesheetSqlDao(ConnectionString);
            testTimesheet = new Timesheet(2, 1, 1, DateTime.Parse("2020-01-01"), 6.0M, true, "Timesheet test");
            base.Setup();
        }

        [TestMethod]
        public void GetTimesheetById_With_Valid_Id_Returns_Correct_Timesheet()
        {
            Timesheet timesheet = dao.GetTimesheetById(1);
            AssertTimesheetsMatch(TIMESHEET_1, timesheet);

            timesheet = dao.GetTimesheetById(2);
            AssertTimesheetsMatch(TIMESHEET_2, timesheet);
        }

        [TestMethod]
        public void GetTimesheetById_With_Invalid_Id_Returns_Null_Timesheet()
        {
            Timesheet timesheet = dao.GetTimesheetById(100);
            Assert.IsNull(timesheet);
        }

        [TestMethod]
        public void GetTimesheetsByEmployeeId_With_Valid_Employee_Id_Returns_List_Of_Timesheets_For_Employee()
        {
            IList<Timesheet> timesheets = dao.GetTimesheetsByEmployeeId(1);

            Assert.AreEqual(2, timesheets.Count);
            AssertTimesheetsMatch(TIMESHEET_1, timesheets[0]);

            AssertTimesheetsMatch(TIMESHEET_2, timesheets[1]);
            timesheets = dao.GetTimesheetsByEmployeeId(2);

            Assert.AreEqual(2, timesheets.Count);
            AssertTimesheetsMatch(TIMESHEET_3, timesheets[0]);
            AssertTimesheetsMatch(TIMESHEET_4, timesheets[1]);
        }

        [TestMethod]
        public void GetTimesheetsByProjectId_With_Valid_Project_Id_Returns_List_Of_Timesheets_For_Project()
        {
            IList<Timesheet> timesheets = dao.GetTimesheetsByProjectId(1);

            Assert.AreEqual(3, timesheets.Count);
            AssertTimesheetsMatch(TIMESHEET_1, timesheets[0]);
            AssertTimesheetsMatch(TIMESHEET_2, timesheets[1]);
            AssertTimesheetsMatch(TIMESHEET_3, timesheets[2]);

            timesheets = dao.GetTimesheetsByProjectId(2);

            Assert.AreEqual(1, timesheets.Count);
            AssertTimesheetsMatch(TIMESHEET_4, timesheets[0]);
        }

        [TestMethod]
        public void CreateTimesheet_Creates_Timesheet()
        {
            Timesheet timesheet = dao.CreateTimesheet(testTimesheet);
            Assert.IsNotNull(timesheet);

            int newId = timesheet.TimesheetId;
            Assert.IsTrue(newId > 0);

            Timesheet retrievedTimesheet = dao.GetTimesheetById(newId);

            AssertTimesheetsMatch(timesheet, retrievedTimesheet);
        }

        [TestMethod]
        public void UpdateTimesheet_Updates_Timesheet()
        {
            Timesheet timesheet = new Timesheet(2, 1, 1, DateTime.Parse("2021-01-01"),
                0.25M, false, "Timesheet 3");

            Timesheet updatedTimesheet = dao.UpdateTimesheet(timesheet);

            AssertTimesheetsMatch(timesheet, updatedTimesheet);
        }

        [TestMethod]
        public void DeleteTimesheetById_Deletes_Timesheet()
        {
            int rowsAffected = dao.DeleteTimesheetById(4);
            Assert.AreEqual(1, rowsAffected);

            Timesheet timesheet = dao.GetTimesheetById(4);
            Assert.IsNull(timesheet);
        }

        [TestMethod]
        public void GetBillableHours_Returns_Correct_Total()
        {


            decimal actualBilliableHours = dao.GetBillableHours(1, 1);

            Assert.AreEqual(2.50M, actualBilliableHours);
        }

        private void AssertTimesheetsMatch(Timesheet expected, Timesheet actual)
        {
            Assert.AreEqual(expected.TimesheetId, actual.TimesheetId);
            Assert.AreEqual(expected.EmployeeId, actual.EmployeeId);
            Assert.AreEqual(expected.ProjectId, actual.ProjectId);
            Assert.AreEqual(expected.DateWorked, actual.DateWorked);
            Assert.AreEqual(expected.HoursWorked, actual.HoursWorked);
            Assert.AreEqual(expected.IsBillable, actual.IsBillable);
            Assert.AreEqual(expected.Description, actual.Description);
        }
    }
}
