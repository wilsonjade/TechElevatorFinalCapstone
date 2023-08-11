import axios from "axios";

export default {
    listEvents() {
        return axios.get("/events");
    },

    getEventsById(eventId) {
        return axios.get(`/events/${eventId}`)
    },

    deleteEvent(eventId){
        return axios.delete(`/events/${eventId}`);
    },
    createEvent(eventObj){
        console.log("reached axios create")
        
        return axios.post("/events/", eventObj);
    },
    updateEvent(eventId,eventObj){
        return axios.put(`/events/${eventId}`,eventObj)
    },
    futureEvents(){
        console.log("reached axios future events")
        return axios.get(`/events/future`)
    }
    
}