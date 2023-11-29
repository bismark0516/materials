import axios from "axios";

const http = axios.create({
  baseURL: "https://localhost:44315",
});

export default {
  list() {
    return http.get("/pet");
  },

  update(updatedPet){
    return http.put(`/pet/${updatedPet.id}`, updatedPet)
  },
};
