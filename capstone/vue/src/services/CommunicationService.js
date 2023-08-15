import axios from "axios";

export default {
    listCommunications() {
        return axios.get("/communications");
    },
    listPolls() {
        //todo
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
    createPoll(newPoll) {
        return axios.post(`/communications/polls`, newPoll)
    },
    updateCommunication(communicationId, updatedCommunication){
        return axios.put(`/communications/${communicationId}`,updatedCommunication)
    },
    getFutureCommunications(){
        return axios.get(`/communications/future`)
    }
    
}