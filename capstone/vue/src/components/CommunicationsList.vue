<template>
  <section>
      <communication-detail v-for="communication in communications" v-bind:key="communication.communicationId" v-bind:item="communication"/>
    <communication-detail v-for="poll in polls" v-bind:key="poll.pollId" />

  </section>
</template>

<script>
import CommunicationDetail from './CommunicationDetail.vue'
export default {
    name: "listCommunications",
    components: {CommunicationDetail},
    data() {
        return {
            
        }
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
        }
    },
    created(){},
}
</script>

<style>

</style>