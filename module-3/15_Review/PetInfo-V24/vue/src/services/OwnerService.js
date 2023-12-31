import axios from "axios";

const http = axios.create({
  baseURL: "https://localhost:44315",
});

export default {
  list() {
    return http.get("/owner");
  },

  addOwner(newOwner) {
    return http.post("/owner", newOwner)
  }
};
