import axios from "axios";

export default {
    listCommunications() {
        return axios.get("/communications");
    },

    getCommunicationById(communicationId) {
        return axios.get(`/communications/${communicationId}`)
    },

    deleteCommunication(communicationId){
        return axios.delete(`/communications/${communicationId}`);
    },
    createCommunication(newCommunication){        
        return axios.post("/communications/", newCommunication);
    },
    updateCommunication(communicationId, updatedCommunication){
        return axios.put(`/communications/${communicationId}`,updatedCommunication)
    },
    getFutureCommunications(){
        return axios.get(`/communications/future`)
    }
    
}