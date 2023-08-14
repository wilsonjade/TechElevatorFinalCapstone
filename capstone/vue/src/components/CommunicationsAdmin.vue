<template>
  <form v-on:submit.prevent="addCommunication" class="card">
      <div>
      <label for="title">Title: </label>
      <input type="text" name="title" id="communication-title" v-model="newCommunication.title">
      </div>
      <div>
      <label for="type">Type: </label>
      <input type="text" name="type" id="communication-type" v-model="newCommunication.type">
      </div>
      <div>
      <label for="description">Description: </label>
      <textarea rows="4" cols="50" name="description" id="communication-description" v-model="newCommunication.description" />
      </div>
      <div>
      <label for="start-time">Start Time: </label>
      <input type="datetime-local" name="start-time" id="communication-start-time" v-model="newCommunication.startTime" />
      </div>
      <div>
      <label for="end-time">End Time: </label>
      <input type="datetime-local" name="end-time" id="communication-end-time" v-model="newCommunication.endTime" />
      </div>


      <button type="submit">Save New Communication</button>
  </form>
</template>

<script>
import CommunicationService from '../services/CommunicationService.js';
export default {
    name: 'CommunicationsAdmin',
    data() {
        return{
            newCommunication: {
                communicationId: 0,
                userId: this.$store.state.user.userId,
                title: '',
                type: '',
                description: '',
                startTime: '',
                endTime: '',
            },
        }
    },
    computed: {
    },
    methods: {
        addCommunication() {
          console.log("reached communicationsAdmin --> addCommunication()")
            CommunicationService.createCommunication(parseInt(this.$route.params.sellerId), this.newRating)
            .then( () => {
                this.$store.commit("LOAD_COMMUNICATIONS");
                this.$router.push({name: "home"});
            })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log("Error updating communications: ", error.response.status);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log("Error updating communications: unable to communicate to server");
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error updating communications: error making request");
          }
        });

        }
    }

}
</script>

<style>

</style>