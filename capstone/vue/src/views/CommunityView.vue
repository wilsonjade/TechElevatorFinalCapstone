<template>
  <section>
      <h1>Welcome to the Community Home Page</h1>
    <!-- include events,forums, communications, buy/sell/trade components here -->
    <events-view />
    <communications-list />
  </section>
</template>

<script>
import CommunicationsList from '../components/CommunicationsList.vue';
import eventsView from "./eventsView.vue";
export default {
  components: { eventsView, CommunicationsList },
};
</script>

<style scoped>
body {
    grid-template-columns: 1fr 1fr;
    grid-template-areas: 
    "events communications"    
    ;
}
</style>