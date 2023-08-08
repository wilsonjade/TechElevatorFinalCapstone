<template>
  <form v-on:submit.prevent="submitForm()">
      <div>
      <label for="id">Id:</label>
      <input v-model="formData.eventId" type="number" id="name" disabled />
    </div>
     
      <div>
      <label for="name">Name:</label>
      <input v-model="formData.name" type="text" id="name" required />
    </div>
    <div>
      <label for="userId">User ID:</label>
      <input v-model="formData.userId" type="number" id="userId" required />
    </div>
    <div>
      <label for="address1">Address:</label>
      <input v-model="formData.address1" type="text" id="address1"  />
    </div>
    <div>
      <label for="city">City:</label>
      <input v-model="formData.city" type="text" id="city"  />
    </div>
    <div>
      <label for="state">State:</label>
      <input v-model="formData.state" type="text" id="state"  />
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
        eventId: null,
        userid: 0,
        address1: '123',
        city: 'cbus',
        state: 'oh',
        zip: '321',
        website: 'http://www.url.com',
        name: 'Nm',
        shortDescription: 'short',
        longDescription: 'long',
        isVirtual: false,
        startTime: null,
        endTime: null,
      },
    };
  },
  methods: {
    submitForm() {
      // Handle form submission here
      console.log(this.formData);
      EventService.updateEvent(this.formData.eventId,this.formData).then(
          response=> alert(response.status)
      ).catch(error=> alert(error.message));
      // You can send the formData to an API, process it, etc.
    },
  },
  created(){
      if(this.$route.params.id){
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