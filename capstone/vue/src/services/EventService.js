import axios from "axios";

export default {
    listEvents() {
        return axios.get("/events");
    },

    getEventsById(eventId) {
        return axios.get(`/events/${eventId}`)
    }

}