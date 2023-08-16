<template>
  <form v-on:submit.prevent="addCommunication()" class="card">
    <div>
      <label for="type">Type: </label>
      <select
        name="type"
        id="communication-type"
        v-model="newCommunication.type"
        required
      >
        <option value="poll">Poll</option>
        <option value="competition">Competition</option>
        <option value="challenge">Challenge</option>
      </select>
    </div>
    <div>
      <label for="title">Title: </label>
      <input
        type="text"
        name="title"
        id="communication-title"
        v-model="newCommunication.title"
      />
    </div>
    <div>
      <label for="start-time">Start Time: </label>
      <input
        type="datetime-local"
        name="start-time"
        id="communication-start-time"
        v-model="newCommunication.startTime"
      />
    </div>
    <div>
      <label for="end-time">End Time: </label>
      <input
        type="datetime-local"
        name="end-time"
        id="communication-end-time"
        v-model="newCommunication.endTime"
      />
    </div>

    <div class="poll-form" v-show="newCommunication.type == 'poll'">
      <p>Please enter poll options below:</p>
      <div>
        <label for="poll-option1">Option 1: </label>
        <input type="text" name="type" v-model="newPollOption1.text" />
      </div>
      <div>
        <label for="poll-option1">Option 2: </label>
        <input type="text" name="type" v-model="newPollOption2.text" />
      </div>
      <div>
        <label for="poll-option1">Option 3: </label>
        <input type="text" name="type" v-model="newPollOption3.text" />
      </div>
      <div>
        <label for="poll-option1">Option 4: </label>
        <input type="text" name="type" v-model="newPollOption4.text" />
      </div>
    </div>

    <button type="submit">Save New Communication</button>
  </form>
</template>

<script>
import CommunicationService from "../services/CommunicationService.js";
export default {
  name: "CommunicationsAdmin",
  data() {
    return {
      newCommunication: {
        communicationId: 0,
        userId: this.$store.state.user.userId,
        title: "",
        type: "",
        description: "",
        startTime: "",
        endTime: "",
      },
      newPollOption1: {
        pollId: 0,
        userId: this.$store.state.user.userId,
        text: "",
      },
      newPollOption2: {
        pollId: 0,
        userId: this.$store.state.user.userId,
        text: "",
      },
      newPollOption3: {
        pollId: 0,
        userId: this.$store.state.user.userId,
        text: "",
      },
      newPollOption4: {
        pollId: 0,
        userId: this.$store.state.user.userId,
        text: "",
      },
    };
  },
  computed: {},
  methods: {
    addCommunication() {
      CommunicationService.createCommunication(this.newCommunication)
        .then(() => {
          this.$store.commit("LOAD_COMMUNICATIONS");
          this.$router.push({ name: "communicationsList" });
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            console.log(
              "Error updating communications: ",
              error.response.status
            );
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            console.log(
              "Error updating communications: unable to communicate to server"
            );
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            console.log("Error updating communications: error making request");
          }
        });

      if (this.newCommunication.type == "poll") {
        this.addPollOptions();
      }
    },
    addPollOptions() {
      if (this.newPollOption1 != "") {
        CommunicationService.createPollOption(
          this.newCommunication.communicationId,
          this.newPollOption1
        )
          .then(() => {
            this.$store.commit("LOAD_POLL_OPTIONS");
            this.$router.push({ name: "communicationsList" });
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log(
                "Error updating communications: ",
                error.response.status
              );
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error updating communications: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log(
                "Error updating communications: error making request"
              );
            }
          });
      }
      if (this.newPollOption2 != "") {
        CommunicationService.createPollOption(
          this.newCommunication.communicationId,
          this.newPollOption2
        )
          .then(() => {
            this.$store.commit("LOAD_POLL_OPTIONS");
            this.$router.push({ name: "communicationsList" });
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log(
                "Error updating communications: ",
                error.response.status
              );
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error updating communications: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log(
                "Error updating communications: error making request"
              );
            }
          });
      }
      if (this.newPollOption3 != "") {
        CommunicationService.createPollOption(
          this.newCommunication.communicationId,
          this.newPollOption3
        )
          .then(() => {
            this.$store.commit("LOAD_POLL_OPTIONS");
            this.$router.push({ name: "communicationsList" });
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log(
                "Error updating communications: ",
                error.response.status
              );
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error updating communications: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log(
                "Error updating communications: error making request"
              );
            }
          });
      }
      if (this.newPollOption4 != "") {
        CommunicationService.createPollOption(
          this.newCommunication.communicationId,
          this.newPollOption4
        )
          .then(() => {
            this.$store.commit("LOAD_POLL_OPTIONS");
            this.$router.push({ name: "communicationsList" });
          })
          .catch((error) => {
            if (error.response) {
              // error.response exists
              // Request was made, but response has error status (4xx or 5xx)
              console.log(
                "Error updating communications: ",
                error.response.status
              );
            } else if (error.request) {
              // There is no error.response, but error.request exists
              // Request was made, but no response was received
              console.log(
                "Error updating communications: unable to communicate to server"
              );
            } else {
              // Neither error.response and error.request exist
              // Request was *not* made
              console.log(
                "Error updating communications: error making request"
              );
            }
          });
      }
    },
  },
};
</script>

<style>
</style>