import axios from "axios";

export default {
    getTaskRemindersByUser(userId){
        return axios.get(`/plant/tasks/${userId}`)
    },
    ackTaskReminder(ackObj){
        return axios.put(`/plant/tasks/${ackObj.userId}`,ackObj)
    },
    listTasks() {
        return axios.get("/plant/tasks/ad");
    },
    getTasksByPlantId(plantId) {
        return axios.get(`/plant/tasks/plant/${plantId}`)
    },
    getTasksById(taskId) {
        return axios.get(`/plant/tasks/ad/${taskId}`)
    },
    deleteTask(taskId){
        return axios.delete(`/plant/${taskId}`);
    },
    addTask(task){
        return axios.post("/plant/", task);
    },
    updateTask(taskId, taskToUpdate){
        return axios.put(`/plant/tasks/ad/${taskId}`,taskToUpdate)
    }
    
}