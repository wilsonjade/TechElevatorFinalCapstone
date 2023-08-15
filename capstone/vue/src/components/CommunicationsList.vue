<template>
  <section>
    <button v-show="isAdmin" v-on:click="$router.push({name: 'communicationsAdmin'})" >Add New Communication</button>

    <communication-detail
      v-for="communication in communications"
      v-bind:key="communication.communicationId"
      v-bind:item="communication"
    />
    <communication-detail v-for="poll in polls" v-bind:key="poll.pollId" />
  </section>
</template>

<script>
import CommunicationDetail from "./CommunicationDetail.vue";
export default {
  name: "listCommunications",
  components: { CommunicationDetail },

  data() {
    return {
      isAdmin: false,
    };
  },
  computed: {
    communications() {
      return this.$store.state.communications;
    },
    futureCommunications() {
      return this.$store.state.futureCommunications;
    },
    polls() {
      return this.$store.state.polls;
    },
  },
  created() {
    this.isAdmin = this.$store.state.user.role == "admin";
  },
};
</script>

<style>
</style>