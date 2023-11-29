import { createStore as _createStore } from "vuex";
import axios from "axios";

import petService from "../services/PetService.js";

export function createStore(currentToken, currentUser) {
  let store = _createStore({
    state: {
      token: currentToken || "",
      user: currentUser || {},

      pets: [],
    },

    mutations: {
      SET_AUTH_TOKEN(state, token) {
        state.token = token;
        localStorage.setItem("token", token);
        axios.defaults.headers.common["Authorization"] = `Bearer ${token}`;
      },

      SET_USER(state, user) {
        state.user = user;
        localStorage.setItem("user", JSON.stringify(user));
      },

      LOGOUT(state) {
        localStorage.removeItem("token");
        localStorage.removeItem("user");
        state.token = "";
        state.user = {};
        axios.defaults.headers.common = {};
      },

      LOAD_PETS(state) {
        petService
          .list()
          .then((response) => {
            console.log("Reached LOAD_PETS in Vuex");
            console.log(response);
            state.pets = response.data;
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log("Error loading pets: ", error.response.status);
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error loading pets: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log("Error loading pets: make request");
            }
          });
      },

      ADD_PET(state, payload) {
        state.pets.push(payload);
      },

      UPDATE_PET(state, payload) {
        let petIndex = state.pets.findIndex((item) => {
          return payload.id == item.id;
        });

        console.log(petIndex);
        state.pets[petIndex] = payload;
      },
    },
  });
  return store;
}
