<template>
  <section class="grid-container" id="community-view">
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

#community-view {
  grid-template-areas: 
    "events-view events-view communications-list";
}

#events-view {
  grid-area: events-view;
  margin-right: 25px;
}

#communications-list {
  grid-area: communications-list;
  margin-right: 25px;
}
</style>