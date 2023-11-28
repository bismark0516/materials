<template>
  <div id="capstone-app">
    <section class="nav">
      <router-link v-bind:to="{ name: 'homeView' }">Home</router-link> |
      <router-link v-bind:to="{ name: 'listPets' }">Show Pets</router-link> |
      <router-link v-bind:to="{ name: 'listOwners' }">Show Owners</router-link>
    </section>

    <pet-header />
    <router-view />
    <pet-footer />
  </div>
</template>

<script>
import PetHeader from "./components/PetHeader.vue";
import PetFooter from "./components/PetFooter.vue";

export default {
  name: "App",
  components: { PetHeader, PetFooter },
  data() {
    return {};
  },
  methods: {},

  created() {

    this.$store.commit("LOAD_PETS");
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}

section.nav {
 margin-bottom:1rem;
}

section.container {
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
}

form {
  margin: 20px;
}

button {
  height: 2rem;
  margin: 0.5rem;
}

table {
  border-collapse: collapse;
  width: 25%;
}

th,
td {
  text-align: left;
  padding: 8px;
}

tr:nth-child(even) {
  background-color: #f2f2f2;
}

td {
  border: 1px solid black;
}

th {
  background-color: #04aa6d;
  color: white;
}
</style>

