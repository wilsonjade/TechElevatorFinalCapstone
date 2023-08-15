<template>
  <section>
      <button v-if="isAdmin" v-on:click="newEvent()"> Add New Event</button>
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
      isAdmin: false
    }
  },
  methods:{
   getListEvents() {
      EventService.listEvents().then(response => this.events = response.data)

    },
    newEvent(){
      this.$router.push({name: "eventAdmin", params:{id: 0}})
    }
  },
  created(){
    console.log('reached events view created')
    this.getListEvents()
    this.isAdmin = this.$store.state.user.role == 'admin'
  }


}
</script>

<style>

</style>