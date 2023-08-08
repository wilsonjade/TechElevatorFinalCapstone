<template>
  <section class="event card">
    <h1 class="headline">This is the event detail: </h1>
    
    <section>
     
    </section>
    <section>
      <h2>Description and details</h2>
    </section>
  </section>

</template>

<script>

import eventService from "../services/EventService.js"

export default {
  name: "event",
  props:["item"],

  methods: {
    getThisEvent(){
      eventService.getEventsById(this.$route.params.eventId)
      .then((response)=>{
        console.log(response)
        this.event = response.data})
    },


  data(){
    return {
      event: {}
    }
  },

  created(){
  //  console.log("Reached created events")
    this.getThisEvent();

  },
}
};

</script>

<style>
</style>