<template>
  <section>
      <communication-detail v-for="communication in communications" v-bind:key="communication.communicationId" v-bind:item="communication"/>


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
        }
    },
    created(){},
}
</script>

<style>

</style>