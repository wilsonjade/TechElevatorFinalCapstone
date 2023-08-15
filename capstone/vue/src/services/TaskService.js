import axios from "axios";

export default {
    getTaskRemindersByUser(userId){
        return axios.get(`/plant/tasks/${userId}`)
    },
    ackTaskReminder(ackObj){
        return axios.put(`/plant/tasks/${ackObj.userId}`,ackObj)
    },
    listTasks() {
        return axios.get("/tasks/ad");
    },
    
}