import axios from "axios";

export default {
    listPlants() {
        return axios.get("/plant");
    },

}