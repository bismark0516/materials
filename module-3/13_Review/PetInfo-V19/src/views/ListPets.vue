<template>
  <div class="hello">
    <pet-header />
    <h1>Pets</h1>
    <section class="container">
      <pet v-for="pet in currentPets" v-bind:key="pet.id" v-bind:item="pet" />
    </section>

    <button v-show="!showForm" v-on:click="showForm = true">Add Pet</button>

    <form v-on:submit.prevent="createNewPet" v-show="showForm">
      <div>
        <label for="name">Name: </label>
        <input type="text" name="name" id="name" v-model="newPet.name" />
      </div>
      <div>
        <label for="type">Type: </label>
        <input type="text" name="type" id="type" v-model="newPet.type" />
      </div>
      <div>
        <label for="age">Age: </label>
        <input type="number" name="age" id="age" v-model="newPet.age" />
      </div>

      <button type="submit">Save Pet</button>
    </form>

    <pet-footer />
  </div>
</template>

<script>
import PetHeader from "../components/PetHeader.vue";
import PetFooter from "../components/PetFooter.vue";
import Pet from "../components/Pet.vue";

export default {
  components: { PetHeader, PetFooter, Pet },
  name: "ListPets",
  data() {
    return {
      showForm: false,
      newPet: {},
    };
  },
  computed: {
    currentPets() {
      return this.$store.state.pets;
    },
  },
  methods: {
    nextPetId() {
      let result = 0;
      this.$store.state.pets.forEach( item => {
        if (item.id > result){
          result = item.id;
        }
      })
      return result + 1;
    },

    createNewPet() {
      if (this.newPet.name) {
        this.newPet.id = this.nextPetId();
        this.$store.commit("ADD_PET", this.newPet);
      }
      this.newPet = {};
      this.showForm = false;
    },
  },
  created() {
    this.$store.commit("LOAD_PETS");
  },

};
</script>

<style scoped>
</style>
