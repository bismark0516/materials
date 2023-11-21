<template>
  <div class="container">
    <table id="tblUsers">
      <thead>
        <tr>
          <th>&nbsp;</th>
          <th>First Name</th>
          <th>Last Name</th>
          <th>Username</th>
          <th>Email Address</th>
          <th>Status</th>
          <th>Actions</th>
        </tr>
      </thead>
      <tbody>
        <tr>
          <td>
            <input type="checkbox" id="selectAll" ref="selectAllCheckbox"
              v-on:change="selectAll"
              :checked="selectedUserIds.length === filteredList.length"/>
          </td>
          <td>
            <input type="text" id="firstNameFilter" v-model="filter.firstName" />
          </td>
          <td>
            <input type="text" id="lastNameFilter" v-model="filter.lastName" />
          </td>
          <td>
            <input type="text" id="usernameFilter" v-model="filter.username" />
          </td>
          <td>
            <input type="text" id="emailFilter" v-model="filter.emailAddress" />
          </td>
          <td>
            <select id="statusFilter" v-model="filter.status">
              <option value>Show All</option>
              <option value="Active">Active</option>
              <option value="Inactive">Inactive</option>
            </select>
          </td>
          <td>&nbsp;</td>
        </tr>
        <tr
          v-for="user in filteredList"
          v-bind:key="user.id"
          v-bind:class="{ deactivated: user.status === 'Inactive' }"
        >
          <td>
            <input type="checkbox" v-bind:id="user.id" v-bind:value="user.id"  v-model="selectedUserIds" ref="userCheckboxes"
              v-on:change="handleCheckboxChange" />
          </td>
          <td>{{ user.firstName }}</td>
          <td>{{ user.lastName }}</td>
          <td>{{ user.username }}</td>
          <td>{{ user.emailAddress }}</td>
          <td>{{ user.status }}</td>
          <td>
            <button class="btnActivateDeactivate" v-on:click="toggleStatus(user.id)" >Activate or Deactivate</button>
          </td>
        </tr>
      </tbody>
    </table>
    <div class="all-actions">
      <button v-on:click="activateUsers"
      :disabled="selectedUserIds.length === 0" >Activate Users</button>
      <button v-on:click="deactivateUsers"
      :disabled="selectedUserIds.length === 0">Deactivate Users</button>
      <button v-on:click="deleteUsers"
      :disabled="selectedUserIds.length === 0">Delete Users</button>
    </div>
    <button v-on:click="showForm = !showForm">Add New User</button>
    <form id="frmAddNewUser" v-show="showForm" v-on:submit.prevent="createUser">
      <div class="field">
        <label for="firstName">First Name:</label>
        <input type="text" id="firstName" name="firstName" v-model="newUser.firstName" />
      </div>
      <div class="field">
        <label for="lastName">Last Name:</label>
        <input type="text" id="lastName" name="lastName" v-model="newUser.lastName" />
      </div>
      <div class="field">
        <label for="username">Username:</label>
        <input type="text" id="username" name="username" v-model="newUser.username"/>
      </div>
      <div class="field">
        <label for="emailAddress">Email Address:</label>
        <input type="text" id="emailAddress" name="emailAddress" v-model="newUser.emailAddress"/>
      </div>
      <button type="submit" class="btn save">Save User</button>
    </form>
  </div>
</template>
<script>
export default {
  data() {
    return {
      filter: {
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: ""
      },
      nextUserId: 7,
      showForm: false,
      newUser: {
        id: null,
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "Active"
      },
      selectedUserIds: [],
      users: [
        {
          id: 1,
          firstName: "John",
          lastName: "Smith",
          username: "jsmith",
          emailAddress: "jsmith@gmail.com",
          status: "Active"
        },
        {
          id: 2,
          firstName: "Anna",
          lastName: "Bell",
          username: "abell",
          emailAddress: "abell@yahoo.com",
          status: "Active"
        },
        {
          id: 3,
          firstName: "George",
          lastName: "Best",
          username: "gbest",
          emailAddress: "gbest@gmail.com",
          status: "Inactive"
        },
        {
          id: 4,
          firstName: "Ben",
          lastName: "Carter",
          username: "bcarter",
          emailAddress: "bcarter@gmail.com",
          status: "Active"
        },
        {
          id: 5,
          firstName: "Katie",
          lastName: "Jackson",
          username: "kjackson",
          emailAddress: "kjackson@yahoo.com",
          status: "Active"
        },
        {
          id: 6,
          firstName: "Mark",
          lastName: "Smith",
          username: "msmith",
          emailAddress: "msmith@foo.com",
          status: "Inactive"
        }
      ]
    };
  },
  methods: {
    getNextUserId() {
      return this.nextUserId++;
    },
    createUser() {
      this.newUser.id = this.getNextUserId();
      this.users.push({ ...this.newUser });
      this.newUser = {
        id: null,
        firstName: "",
        lastName: "",
        username: "",
        emailAddress: "",
        status: "Active"
      };
      this.showForm = false;
    },
    toggleStatus(userId) {
      const userIndex = this.users.findIndex(user => user.id === userId);
      if (userIndex !== -1) {
        this.users[userIndex].status = (this.users[userIndex].status === 'Active') ? 'Inactive' : 'Active';
      }
    },
    deactivateUsers() {
      this.selectedUserIds.forEach((userId) => {
        const userIndex = this.users.findIndex((user) => user.id === userId);
        if (userIndex !== -1) {
          this.users[userIndex].status = 'Inactive';
        }
      });
      this.selectedUserIds = [];
    },
    deleteUsers() {
      this.selectedUserIds.forEach((userId) => {
        this.users = this.users.filter((user) => user.id !== userId);
      });
      this.selectedUserIds = [];
    },
    activateUsers() {
      this.selectedUserIds.forEach((userId) => {
        const userIndex = this.users.findIndex((user) => user.id === userId);
        if (userIndex !== -1) {
          this.users[userIndex].status = 'Active';
        }
      });
      this.selectedUserIds = [];
    },
    selectAll() {
      if (this.selectedUserIds.length === this.filteredList.length) {
        this.selectedUserIds = [];
      } else {
        this.selectedUserIds = this.filteredList.map(user => user.id);
      }
    },
    updateSelectAll() {
      this.$refs.selectAllCheckbox.checked =
        this.selectedUserIds.length === this.filteredList.length;
    },
    handleCheckboxChange() {
      this.selectedUserIds = this.$refs.userCheckboxes
        .filter(checkbox => checkbox.checked)
        .map(checkbox => parseInt(checkbox.value));
        this.updateSelectAll();
    },
    watch: {
    filteredList() {
      this.updateSelectAll();
    },
  },
  },
  computed: {
    filteredList() {
      let filteredUsers = this.users;
      if (this.filter.firstName != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.firstName
            .toLowerCase()
            .includes(this.filter.firstName.toLowerCase())
        );
      }
      if (this.filter.lastName != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.lastName
            .toLowerCase()
            .includes(this.filter.lastName.toLowerCase())
        );
      }
      if (this.filter.username != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.username
            .toLowerCase()
            .includes(this.filter.username.toLowerCase())
        );
      }
      if (this.filter.emailAddress != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.emailAddress
            .toLowerCase()
            .includes(this.filter.emailAddress.toLowerCase())
        );
      }
      if (this.filter.status != "") {
        filteredUsers = filteredUsers.filter((user) =>
          user.status === this.filter.status
        );
      }
      return filteredUsers;
    }
  }
};
</script>
<style scoped>
table {
  margin-top: 20px;
  font-family: -apple-system, BlinkMacSystemFont, "Segoe UI", Roboto, Oxygen,
    Ubuntu, Cantarell, "Open Sans", "Helvetica Neue", sans-serif;
  margin-bottom: 20px;
}
th {
  text-transform: uppercase;
}
td {
  padding: 10px;
}
tr.deactivated {
  color: red;
}
input,
select {
  font-size: 16px;
}
form {
  margin: 20px;
  width: 350px;
}
.field {
  padding: 10px 0px;
}
label {
  width: 140px;
  display: inline-block;
}
button {
  margin-right: 5px;
}
.all-actions {
  margin-bottom: 40px;
}
.btn.save {
  margin: 20px;
  float: right;
}
</style>

