import axios from "axios";

export default {
    listSellers() {
        return axios.get("/sellers");
    },

    getSellersById(sellerId) {
        return axios.get(`/sellers/${sellerId}`)
    },

    getSellersByPlant(plantId) {
        return axios.get(`/sellers/${plantId}`)
    },

    deleteSeller(sellerId){
        return axios.delete(`/sellers/${sellerId}`);
    },
    createSeller(seller){
        console.log("reached axios create")        
        return axios.post("/sellers/", seller);
    },
    updateSeller(sellerId, seller){
        return axios.put(`/sellers/${sellerId}`,seller)
    }
    
}