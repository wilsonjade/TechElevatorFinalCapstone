<template>
  <section class="eventDetail card">
    <p v-if="item.isVirtual">This Event is Virtual</p>
    <p>
      Starts:
      {{ item.startTimeObj | dateFormat("dddd, MMM D, YYYY - h:mm a ") }}
    </p>
    <p>
      Ends: {{ item.endTimeObj | dateFormat("dddd, MMM D, YYYY - h:mm a ") }}
    </p>
    <p>{{ item.longDescription }}</p>

    <button
      v-if="isAdmin"
      v-on:click="
        $router.push({ name: 'eventAdmin', params: { id: item.eventId } })
      "
    >
      Edit Event
    </button>
    <button v-if="isAdmin" v-on:click="deleteThisEvent()">Delete Event</button>
  </section>
</template>

<script>
import eventService from "../services/EventService.js";

export default {
  name: "event",
  props: ["item"],

  methods: {
    deleteThisEvent() {
      let wasSuccess = false;
      let errorMsg;
      eventService
        .deleteEvent(this.item.eventId)
        .then((response) => {
          wasSuccess = response.status == 200;
          alert(
            wasSuccess
              ? "Event Deleted"
              : "Event deletion unsuccessful, please try again"
          );
          this.$router.go(0); //refresh view
        })
        .catch((error) => {
          if (error.response) {
            // error.response exists
            // Request was made, but response has error status (4xx or 5xx)
            errorMsg = `Error deleting event: ${error.response.status}`;
            alert(errorMsg);
          } else if (error.request) {
            // There is no error.response, but error.request exists
            // Request was made, but no response was received
            errorMsg = "Error deleting event: unable to communicate to server";
            alert(errorMsg);
          } else {
            // Neither error.response and error.request exist
            // Request was *not* made
            errorMsg = "Error deleting event: error making request";
            alert(errorMsg);
          }
        });
    },
    // getThisEvent(){
    //   eventService.getEventsById(this.$route.params.eventId)
    //   .then((response)=>{
    //     console.log(response)
    //     this.event = response.data})
    // },
  },
  data() {
    return {
      isAdmin: false,
      event: {},
    };
  },

  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
  },
};
</script>

<style scoped>
.card {
  background-color: #f6f7e89a;
}
</style>