<template>
  <form v-on:submit.prevent="submitForm()">
      <div>
      <label for="taskId">Task Id:</label>
      <input v-model.number="formData.taskId" type="number" id="name"  />
    </div>
    <div>
      <label for="plantId">Plant Id:</label>
      <input v-model.number="formData.plantId" v-bind:placeholder="plantId"  type="number" id="plantId"  />
    </div>
    <div>
      <label for="taskDescription">Description:</label>
      <input v-model="formData.taskDescription" type="text" id="taskDescription"  />
    </div>
    <div>
      <label for="taskCategory">Category:</label>
      <input v-model="formData.taskCategory" type="text" id="taskCategory"  />
    </div>
    <div>
      <label for="frequencyDays">Frequency in Days:</label>
      <input v-model.number="formData.frequencyDays" type="number" id="frequencyDays"  />
    </div>
   
    <button type="submit">Submit</button>
  </form>
</template>

<script>
import taskService from '../services/TaskService';
export default {
    name: 'taskAdmin',
  data() {
    return {
    testobj: {},
      formData: {
        taskId: 0,
        plantId: 0,
        taskDescription: '',
        taskCategory: '',
        frequencyDays: 0,
      },
    };
  },
  computed: {
    // userid(){return this.$store.state.user.userId}
  },
  methods: {
    submitForm() {
      // Handle form submission here
   
      //if id = 0 , call POST
      if(this.formData.taskId === 0 || this.formData.taskId == null){
        // this.formData.userid = this.userid //set userId

        
        taskService.addTask(this.formData).then(response=> {
        alert(response.status == 201 ? "Task created successfully" : response.status)
          this.$router.push({name: "searchView"});} //refresh view
        ).catch((error)=>{
        alert(error.message)
        alert(error.statusText)}
        );
      }else{
      //if id != 0 , call PUT
      taskService.updateTask(this.formData.taskId,this.formData).then(
          response=> {if(response.status == 200){alert("Update successful")}
          
          this.$router.push({name: "searchView"}); //refresh view
          }
      ).catch(error=> alert(error.message));}

    },
  // deleteTask() {
  //     let wasSuccess = false;
  //     let errorMsg;
  //     taskService
  //       .deleteTask(this.item.taskId)
  //       .then((response) => {
  //         wasSuccess = response.status == 200;
  //         alert(
  //           wasSuccess
  //             ? "Task Deleted"
  //             : "Task deletion unsuccessful, please try again"
  //         );
  //         this.$router.go(0); //refresh view
  //       })
  //       .catch((error) => {
  //         if (error.response) {
  //           // error.response exists
  //           // Request was made, but response has error status (4xx or 5xx)
  //           errorMsg = `Error deleting task: ${error.response.status}`;
  //           alert(errorMsg);
  //         } else if (error.request) {
  //           // There is no error.response, but error.request exists
  //           // Request was made, but no response was received
  //           errorMsg = "Error deleting task: unable to communicate to server";
  //           alert(errorMsg);
  //         } else {
  //           // Neither error.response and error.request exist
  //           // Request was *not* made
  //           errorMsg = "Error deleting task: error making request";
  //           alert(errorMsg);
  //         }
  //       });
  //   },
  
  },
  created(){
     this.isAdmin = this.$store.state.user.role == "admin";
    //call database for valid list of seller IDs
    if (this.$route.params.plantId) {
      taskService.getTasksByPlantId(this.$route.params.plantId).then(
        (response) => {
          this.filteredTasksByPlant = response.data;
        }
      );
    }
  },
  
};
</script>

<style scoped>
/* Add your styling here */
</style>