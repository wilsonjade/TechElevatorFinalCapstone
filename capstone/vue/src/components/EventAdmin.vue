<template>
  <form class="card" v-on:submit.prevent="submitForm()">
    <div>
      <label for="name">Name:</label>
      <input v-model="formData.name"  type="text" id="name"  required />
    </div>
    <div>
      <label for="address1">Address:</label>
      <input v-model="formData.address1" type="text" id="address1"  />
    </div>
    <div>
      <label for="address2">Address Line 2:</label>
      <input v-model="formData.address2" type="text" id="address2"  />
    </div>
    <div>
      <label for="city">City:</label>
      <input v-model="formData.city" type="text" id="city"  />
    </div>
    <div>
      <label for="state">State:</label>
      <input v-model="formData.state" maxlength="2" type="text" id="state"  />
    </div>
    <div>
      <label for="zip">Zip:</label>
      <input v-model="formData.zip" type="text" id="zip"  />
    </div>
    <div>
      <label for="website">Website:</label>
      <input v-model="formData.website" type="text" id="website" />
    </div>
    
    <div>
      <label for="short_description">Short Description:</label>
      <input v-model="formData.shortDescription" type="text" id="short_description" />
    </div>
    <div>
      <label for="long_description">Long Description:</label>
      <textarea v-model="formData.longDescription" id="long_description"></textarea>
    </div>
    <div>
      <label for="is_virtual">Is Virtual:</label>
      <input v-model="formData.isVirtual" type="checkbox" id="is_virtual" />
    </div>
     <div>
      <label for="start_time">Start Time:</label>
      <input v-model="formData.startTime" type="datetime-local" id="start_time" required />
    </div>
    <div> 
      <label for="end_time">End Time:</label>
      <input v-model="formData.endTime" type="datetime-local" id="end_time" required />
    </div>
    <button type="submit">Submit</button>
  </form>
</template>

<script>
import EventService from '../services/EventService';
export default {
    name: 'EventAdmin',
  data() {
    return {
    testobj: {},
      formData: {
        eventId: 0,
        userid: 0,
        address1: '',
        address2: '',
        city: '',
        state: '',
        zip: '',
        website: '',
        name: '',
        shortDescription: '',
        longDescription: '',
        isVirtual: false,
        startTime: '2023-08-15T12:00:00',
        endTime: '2023-08-15T13:00:00',
      },
    };
  },
  computed: {
    userid(){return this.$store.state.user.userId}
  },
  methods: {
    submitForm() {
      // Handle form submission here
   
      //if id = 0 , call POST
      if(this.formData.eventId === 0 || this.formData.eventId == null){
        this.formData.userid = this.userid //set userId

        
        EventService.createEvent(this.formData).then(response=> {
        alert(response.status == 201 ? "Event created successfully" : response.status)
          this.$router.push({name: "eventsView"});} //refresh view
        ).catch((error)=>{
        alert(error.message)
        alert(error.statusText)}
        );
      }else{
      //if id != 0 , call PUT
      EventService.updateEvent(this.formData.eventId,this.formData).then(
          response=> {if(response.status == 200){alert("Update successful")}
          
          this.$router.push({name: "communityView"}); //refresh view
          }
      ).catch(error=> alert(error.message));}

    },
  },
  created(){
    //populate in existing data if id is valid
      if(this.$route.params.id != 0){
          EventService.getEventsById(this.$route.params.id)
          .then( response =>{
          this.testobj = response.data;
              this.formData = response.data;}
          )
      }
      
  }
};
</script>

<style scoped>
/* Add your styling here */
</style>