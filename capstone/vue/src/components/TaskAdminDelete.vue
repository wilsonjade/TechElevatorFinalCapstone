<template>
  <section class="task-admin-delete">
    <h1>Delete Task</h1>
    
     <form v-on:submit.prevent="submitForm()">
      <div>
      <label for="taskId">Task Id:</label>
      <input v-model.number="formData.taskId" type="number" id="name"  />
    </div>

    
     <button type="submit">Submit</button>
  </form>
    
    
  </section>
</template>

<script>
import taskService from '../services/TaskService.js'

export default {
  components: {},
  name: "taskDelete",
  props: ["item"],
  data() {
    return {
      isAdmin: false,
      seller: {},
    };
  },
  methods: {
    deleteTask() {
      let wasSuccess = false;
      let errorMsg;
      taskService
        .deleteTask(this.item.taskId)
        .then((response) => {
          wasSuccess = response.status == 200;
          alert(
            wasSuccess
              ? "Task Deleted"
              : "Task deletion unsuccessful, please try again"
          );
          this.$router.go(0); //refresh view
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            errorMsg = `Error deleting task: ${error.response.status}`;
            alert(errorMsg);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            errorMsg = "Error deleting task: unable to communicate to server";
            alert(errorMsg);
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            errorMsg = "Error deleting task: error making request";
            alert(errorMsg);
          }
        });
    },
    
    created() {
      this.isAdmin = this.$store.state.user.role == "admin";
    },
  },
};
</script>

<style>
</style>