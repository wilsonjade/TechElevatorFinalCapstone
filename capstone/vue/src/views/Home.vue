<template>
  <div class="home">
  
    <notification-display />
  </div>
</template>

<script>
import NotificationDisplay from "../components/NotificationDisplay.vue";
export default {
  components: { NotificationDisplay },
  name: "home",
};
</script>
