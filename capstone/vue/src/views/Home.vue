<template>
  <div class="home">
    <notification-display />
    <h1>Home</h1>
    <p>You are logged in</p>
  </div>
</template>

<script>
import NotificationDisplay from '../components/NotificationDisplay.vue';
export default {
  components: {NotificationDisplay  },
  name: "home"
};
</script>
