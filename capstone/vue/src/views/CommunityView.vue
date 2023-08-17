<template>
  <section class="grid-container" id="community-view">
    <!-- include events,forums, communications, buy/sell/trade components here -->
    <h2 class="events-header heading" >Upcoming Events</h2>
    <events-view />
    <h2 class="communications-header heading" >Communications</h2>
    <communications-list />
    <h2 class="garden-list-header heading" >Gardens</h2>
    <virtual-garden-list-view />
  </section>
</template>

<script>
import CommunicationsList from '../components/CommunicationsList.vue';
import eventsView from "./eventsView.vue";
import VirtualGardenListView from './virtualGardenListView.vue';

export default {
  components: { eventsView, CommunicationsList, VirtualGardenListView },
};
</script>

<style scoped>

#community-view {
  grid-template-columns: 50% 25% 25%;
  grid-template-areas: 
    "events-header communications-header garden-list-header"
    "events-view communications-list garden-list-container"
    "seller-list seller-list garden-list-container"
    ;
  margin: auto;
}

#events-view {
  grid-area: events-view;
  margin: 0 auto;
  min-width: 100%;
}

#communications-list {
  grid-area: communications-list;
  margin: 0 auto;
}

#gardenlistcontainer {
  grid-area: garden-list-container;
}

.events-header {
  grid-area: events-header;
}

.communications-header {
  grid-area: communications-header;
}

.garden-list-header {
  grid-area: garden-list-header;
}

.heading {
  text-align: center;
  margin-top: 1rem;
  margin-bottom: 0;
}
</style>