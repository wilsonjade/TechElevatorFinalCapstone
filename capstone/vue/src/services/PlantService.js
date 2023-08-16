import axios from "axios";

export default {
    listPlants() {
        return axios.get("/plant");
    },
    listGardenPlants(userId){
        return axios.get(`/plant/garden/${userId}`)
    },
    getPlantById(plantId) {
        return axios.get(`/plant/${plantId}`)
    },
    getPlantByCommonName(commonName){
        return axios.get(`/plant/name/${commonName}`)
    },
    addToGarden(plantUser){
        return axios.post(`/plant/garden`,plantUser)
    },
    removeFromGarden(plantUser){
        return axios.delete("/plant/garden/",{data: plantUser})

    }
    ,
    getAllGardens(){
        return axios.get("/plant/gardens/")
    }
}