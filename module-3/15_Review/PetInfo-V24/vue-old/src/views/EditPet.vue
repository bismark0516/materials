<template>
  <section>
    <h1>Welcome to Edit Pet</h1>
    <form v-on:submit.prevent="savePet">
      <div>
        <label for="id">Id: </label>
        {{ localPet.id }}
      </div>
      <div>
        <label for="name">Name: </label>
        <input type="text" name="name" id="name" v-model="localPet.name" />
      </div>
      <div>
        <label for="type">Type: </label>
        <input type="text" name="type" id="type" v-model="localPet.type" />
      </div>
      <div>
        <label for="age">Age: </label>
        <input type="number" name="age" id="age" v-model.number="localPet.age" />
      </div>

            <div>
        <label for="owner">Owner Id: </label>
        <input type="number" name="owner" id="owner" v-model.number="localPet.owner" />
      </div>

      <button type="submit">Save Pet</button>
    </form>
  </section>
</template>

<script>
import petService from "../services/PetService.js";

export default {
  name: "EditPet",

  data() {
    return {
      petId: 0,
      localPet: {},
    };
  },

  methods: {
    savePet() {
      console.log("Reached savePet");
      //todo call axios

      petService.update(this.localPet)
        .then(() => {
          this.$store.commit("LOAD_PETS");
          this.$router.push({ name: "listPets" });
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error updating pets: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log("Error updating pets: unable to communicate to server");
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error updating pets: error making request");
          }
        });
    },
  },

  created() {
    this.petId = this.$route.params.petId;

    const pet = this.$store.state.pets.find((item) => {
      return this.petId == item.id;
    });

    this.localPet = {};
    this.localPet.id = pet.id;
    this.localPet.name = pet.name;
    this.localPet.type = pet.type;
    this.localPet.age = pet.age;
    this.localPet.owner = pet.owner;
  },
};
</script>

<style>
</style>