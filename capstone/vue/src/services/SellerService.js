import axios from "axios";

export default {
    listSellers() {
        return axios.get("/seller");
    },

    getSellersById(sellerId) {
        return axios.get(`/seller/${sellerId}`)
    },

    getSellersByPlant(plantId) {
        return axios.get(`/seller/${plantId}`)
    },

    deleteSeller(sellerId){
        return axios.delete(`/seller/${sellerId}`);
    },
    createSeller(seller){
        console.log("reached axios create")        
        return axios.post("/seller/", seller);
    },
    updateSeller(sellerId, seller){
        return axios.put(`/seller/${sellerId}`,seller)
    }
    
}