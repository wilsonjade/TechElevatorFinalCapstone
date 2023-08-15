import axios from "axios";

export default {
    listCommunications() {
        return axios.get("/communications");
    },
    listCommunicationsByType(communicationType) {
        return axios.get(`/communications/${communicationType}`)
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
    createPollOption(newPollOption) {
        return axios.post(`/communications/polls`, newPollOption)
    },
    updateCommunication(communicationId, updatedCommunication){
        return axios.put(`/communications/${communicationId}`,updatedCommunication)
    },
    getFutureCommunications(){
        return axios.get(`/communications/future`)
    }
    
}