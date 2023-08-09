<template>
  <div class="event card">
    <section >
      <h1>{{ item.name }}</h1>
      <h2>{{ item.shortDescription }}</h2>
     
    </section>
    <section>
      <event-detail v-bind:item="item" v-bind:display="display"/>
    </section>
  </div>
</template>

<script>
import eventService from "../services/EventService.js";
import EventDetail from './EventDetail.vue';
 
export default {
  components: { EventDetail },
  name: "eventCard",
  props: ["item"],

  methods: {
    deleteThisEvent() {
      let wasSuccess = false;
      let errorMsg;
      eventService
        .deleteEvent(this.item.eventId)
        .then((response) => {
          wasSuccess = response.data;
          alert(
            wasSuccess
              ? "Event Deleted"
              : "Event deletion unsuccessful, please try again"
          );
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
    //  console.log("Reached created events")
    // this.getThisEvent();
    this.isAdmin = this.$store.state.user.role;
  },
};
</script>

<style>
</style>