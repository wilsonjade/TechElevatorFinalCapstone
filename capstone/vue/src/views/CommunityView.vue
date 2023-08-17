<template>
  <section class="grid-container" id="community-view">
    <!-- include events,forums, communications, buy/sell/trade components here -->
    <events-view />
    <virtual-garden-list-view />
    <communications-list />
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
  grid-template-columns: 1fr 1fr 20%;
  grid-template-areas: 
    "events-view communications-list garden-list-container"
    "seller-list seller-list garden-list-container"
    ;
  margin: auto;
}

#events-view {
  grid-area: events-view;
  margin: 0 auto;
}

#communications-list {
  grid-area: communications-list;
  margin: 0 auto;
}

#gardenlistcontainer {
  grid-area: garden-list-container;
}
</style>