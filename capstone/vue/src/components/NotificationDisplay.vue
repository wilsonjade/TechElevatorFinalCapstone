<template>
  <div v-bind:class="classes">
    <div v-on:click="hideAlert()" v-for="alert in alerts" v-bind:key="alert" class="alert">
       {{ alert }} <img src="" />
    </div>
  </div>
</template>

<script>
 import eventService from "../services/EventService.js"

export default {
  data() {
    return {
      alerts : []
      ,
      futureEvents: []
    };

  },
  name: "NotificationDisplay",
  methods: {
    hideAlert(){
      console.log('reachedhidealert')
    //  document.getElementsByClassName("alert")[0].classList.add('hide');
      this.alerts.pop();
    },
    getAlerts() {
      
      let events = this.futureEvents;
      
      let alerts = [];
      events.forEach((e) => {
        let dt = new Date(e.startTime);
        let twoDays = 1000 * 60 * 60 * 48; //two days in milliseconds
        let now = new Date();
        if ((dt - now < twoDays) && (dt - now > 0)) {
          this.alerts.push(
            `Reminder! Upcoming event ${e.name} is on ${dt.toLocaleDateString('en-us', { weekday:"long",  month:"short", day:"numeric"})}`
          )
        }
      });

      return alerts;
    },
  },
  computed: {
    classes() {
      return `alertcontainer ${this.alerts.length > 0 ? "show" : "hide"}`;
    },
    
  },
  created(){
    eventService.futureEvents().then(response=>{
    this.futureEvents = response.data;
    this.getAlerts();
    }
    );
  }
};
</script>

<style>

.show {
  display: flex;
}
.hide {
  display: none;
}
.alertcontainer {
  z-index: 5;
  position: absolute;
  top: 20%;
  left: 15%;
  max-width: 45%;
  flex-direction: row;
  justify-content: flex-start;
  flex-wrap: wrap;
  border-style: solid;
  padding: 5px;
  box-shadow: 5px 10px darkslategray;
  border-radius: 30px;
  background-color: steelblue;
}
.alert {
  min-width: 51%;
  margin-top: 5%;
  margin-bottom: 5%;
  border-style: solid;
  padding: 5px;
  box-shadow: 2px 2px slategrey;
  border-radius: 10px;
  background-color: springgreen;
}
</style>