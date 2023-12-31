﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Reflection;

namespace Exercises.Tests
{
    public class MethodValidator
    {
        public static void ValidatePublicMethod(MethodInfo method, string name, Type returnType)
        {
            Assert.IsNotNull(method, $"You do not have the {name} method");
            Assert.AreEqual(returnType, method.ReturnType, $"Your {name} method should return a bool");
            Assert.AreEqual(true, method.IsPublic, $"{name} should be a public method");
        }
    }
}
