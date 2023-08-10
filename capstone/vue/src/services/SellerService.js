import axios from "axios";

export default {
    listSellers() {
        return axios.get("/seller");
    },

    getSellersById(sellerId) {
        return axios.get(`/seller/${sellerId}`)
    },

    getSellersByPlantId(plantId) {
        return axios.get(`/seller/plant/${plantId}`)
    },

    deleteSeller(sellerId){
        return axios.delete(`/seller/${sellerId}`);
    },
    createSeller(seller){
        return axios.post("/seller/", seller);
    },
    updateSeller(sellerId, seller){
        return axios.put(`/seller/${sellerId}`,seller)
    }
    
}