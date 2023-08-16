<template>
  <form
    v-on:submit.prevent="submitPollResponse()"
    class="communication-detail card poll"
  >
    <h3>{{ item.title }}</h3>

    <section class="poll-details" v-show="item.type == 'poll'">
      <div>
        <input type="radio" name="poll-item" v-model="choice" value="0" id="poll-option1" />
        <label for="poll-option1">{{ currentPollOptions[0].text }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" v-model="choice" value="1" id="poll-option2" />
        <label for="poll-option2">{{ currentPollOptions[1].text }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" v-model="choice" value="2" id="poll-option3" />
        <label for="poll-option3">{{ currentPollOptions[2].text }}</label>
      </div>

      <div>
        <input type="radio" name="poll-item" v-model="choice" value="3" id="poll-option4" />
        <label for="poll-option4">{{ currentPollOptions[3].text }}</label>
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
      pollId: this.item.communicationId,
      choice: -1,
    };
  },
  computed: {
    currentPollOptions() {
      return this.$store.state.pollOptions.filter( pollOption => {
         return pollOption.pollId == this.item.communicationId
      } )
    }
  },
  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
    this.$store.commit("LOAD_POLL_OPTIONS");
  },
};
</script>

<style scoped>
.poll {
  display: flex;
  flex-direction: column;
}

div {
  padding: 4px;
}

.card {
  max-width: 450px;
}
</style>