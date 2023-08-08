<template>
  <section>
      <h1>this is the eventsView</h1>
      <p> list of eventsView here</p>
      <event-card v-for="event in events" v-bind:key="event.id" v-bind:item="event"/>
        
  </section>
 
</template>

<script>
import EventCard from '../components/EventCard.vue'
// import EventDetail from '../components/EventDetail.vue'
import EventService from '../services/EventService'
export default {
  components: { EventCard },
    name: "EventsView",
  data(){
    return{
      events:{},
    }
  },
  methods:{
    getListEvents() {
      EventService.listEvents().then(response => this.events=response.data)

    }
  },
  created(){
    this.getListEvents()
  }


}
</script>

<style>

</style>