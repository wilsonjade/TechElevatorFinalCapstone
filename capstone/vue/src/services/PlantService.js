import axios from "axios";

export default {
    listPlants() {
        return axios.get("/plant");
    },

    getPlantById(plantId) {
        return axios.get(`/plant/${plantId}`)
    }

}