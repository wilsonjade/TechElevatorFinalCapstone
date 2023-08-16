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