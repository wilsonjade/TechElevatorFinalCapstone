<template>
  <form
    v-on:submit.prevent="submitPollResponse()"
    class="communication-detail card poll"
  >
    <h3>{{ item.title }}</h3>

    <section class="poll-details" v-show="item.type == 'poll'">
      <div>
        <input type="radio" name="poll-item" id="poll-option1" />
        <label for="poll-option1">{{ item.pollOption1 }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" id="poll-option2" />
        <label for="poll-option2">{{ item.pollOption2 }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" id="poll-option3" />
        <label for="poll-option3">{{ item.pollOption3 }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" id="poll-option4" />
        <label for="poll-option4">{{ item.pollOption4 }}</label>
      </div>
    <button>Submit your answer!</button>
    </section>

    <section class="challenge-details" v-show="item.type == 'challenge'">
      <button>Challenge Completed</button>
    </section>

    <section class="competition-details" v-show="item.type == 'competition'">
      <button>Join the Competition!</button>
    </section>


    <button v-on:click="deleteCommunication" v-show="isAdmin">Delete this {{ item.type }}</button>
  </form>
</template>

<script>
import communicationService from '../services/CommunicationService.js'
export default {
  name: "communicationsDetail",
  props: ["item"],
  methods: {
    submitPollResponse() {},
    
    deleteCommunication() {
      let wasSuccess = false;
      let errorMsg;
      communicationService
        .deleteCommunication(this.item.communicationId)
        .then((response) => {
          wasSuccess = response.status == 200;
          alert(
            wasSuccess
              ? "Communication Deleted"
              : "Communication deletion unsuccessful, please try again"
          );
          this.$router.go(0); //refresh view
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            errorMsg = `Error deleting communication: ${error.response.status}`;
            alert(errorMsg);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            errorMsg = "Error deleting communication: unable to communicate to server";
            alert(errorMsg);
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            errorMsg = "Error deleting communication: error making request";
            alert(errorMsg);
          }
        });
    }
  },
  data() {
    return {
      isAdmin: false,
      currentCommunication: {},
    };
  },
  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
    this.currentCommunication.title = this.item.title;
  },
};
</script>

<style scoped>
h1 {
  text-align: center;
}

.poll {
  display: flex;
  flex-direction: column;
}

div {
  padding: 4px;
}
</style>