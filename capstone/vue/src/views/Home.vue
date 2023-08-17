<template>
  <div class="home">
    <h1>Home</h1>
    <p>You are logged in</p>
  
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
