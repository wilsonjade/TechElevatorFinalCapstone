<template>
  <div v-bind:class="classes">
    <div v-on:click="ackAlertEvent(alertEvent)" v-for="alertEvent in alertsEvents" v-bind:key="alertEvent" class="alert">
       <img src="../assets/checkicon.png" /> {{ alertEvent }} 
    </div>
    <div v-on:click="ackAlertTask(alertTask.taskId)" v-for="alertTask in alertsTasks" v-bind:key="alertTask.taskId" class="alert">
       <img src="../assets/checkicon.png" /> {{ alertTask.taskId }} {{alertTask.plantId}}{{alertTask.category}} {{alertTask.descr}}
    </div>
  </div>
</template>

<script>
 import eventService from "../services/EventService.js"
 import TaskService from "../services/TaskService.js"

export default {
  data() {
    return {
      alertsEvents : []
      ,
      alertsTasks: [{taskId: 1, descr: "test1"},{taskId: 2, descr: "test2"},{taskId: 3, descr: "test3"}]
      ,
      futureEvents: []
    };

  },
  name: "NotificationDisplay",
  methods: {
    ackAlertEvent(alertEvent){
    
      this.alertsEvents = this.alertsEvents.filter(e=> e != alertEvent) //update client list of alerts
      //todo PUT to server to acknowledge event 
      //refresh future events 
    },
    ackAlertTask(taskId){
      //todo PUT to server to acknowledge task user_ack_task object
      const now = new Date();
      let ackObj = {"taskId": taskId, "userId": this.$store.state.user.userId, "lastAck": now }
      TaskService.ackTaskReminder(ackObj).then(
        this.getTaskAlerts() //refresh alerts
        )
      //this.alertsTasks = this.alertsTasks.filter(e=> e.taskId != taskId); //update client list of alerts
    },
    getTaskAlerts(){
      TaskService.getTaskRemindersByUser(this.$store.state.user.userId).then(response=>
        this.alertsTasks = response.data
      ).catch(error=>
        console.log(error.message)
      )
    }
    ,
    getEventAlerts() {
      const role = this.$store.state.user.role;
      let alerts = [];
      if(role != 'user'){return alerts} //don't show any notifications if role is not user
      
      let events = this.futureEvents;
      events.forEach((e) => {
        let dt = new Date(e.startTime);
        let twoDays = 1000 * 60 * 60 * 48; //two days in milliseconds
        let now = new Date();
        if ((dt - now < twoDays) && (dt - now > 0)) {
          this.alertsEvents.push(
            `Reminder! Upcoming event ${e.name} is on ${dt.toLocaleDateString('en-us', { weekday:"long",  month:"short", day:"numeric"})}`
          )
        }
      });

      return alerts;
    },
  },
  computed: {
    classes() {
      return `alertcontainer ${(this.alertsEvents.length + this.alertsTasks.length) > 0 ? "show" : "hide"}`;
    },
    
  },
  created(){
    eventService.futureEvents().then(response=>{
    this.futureEvents = response.data;
    this.getEventAlerts();
    this.getTaskAlerts();
    }
    );
  }
};
</script>

<style>
div>img{
  height:20px;
  width: 20px; 
  margin-right: 10px;
}
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
  padding: 15px;
  box-shadow: 5px 10px darkslategray;
  border-radius: 30px;
  background-color: steelblue;
}
.alert {
  min-width: 51%;
  margin-top: 5%;
  margin-bottom: 1%;
  border-style: solid;
  padding: 5px;
  box-shadow: 2px 2px slategrey;
  border-radius: 10px;
  background-color: springgreen;
}
</style>