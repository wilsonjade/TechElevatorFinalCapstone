import axios from "axios";

export default {
    listRatings() {
        return axios.get("/ratings");
    },

    listRatingsBySellerId(sellerId) {
        return axios.get(`/ratings/seller/${sellerId}`)
    },

    deleteRating(ratingId){
        return axios.delete(`/ratings/${ratingId}`);
    },
    createRating(sellerId, rating){
        return axios.post(`/ratings/seller/${sellerId}`, rating);
    },    
}