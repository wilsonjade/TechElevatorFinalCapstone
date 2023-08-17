<template>
  <div v-bind:class="classes">
    <div class="containertitle"> Notifications </div>
    <div v-on:click="ackAlertEvent(alertEvent)" v-bind:id="alertEvent" v-for="alertEvent in alertsEvents" v-bind:key="alertEvent" class="alert">
       <img src="../assets/checkicon.png" /> {{ alertEvent }} 
    </div>
    <div v-on:click="ackAlertTask(alertTask.taskId)" v-bind:id="alertTask.taskId" v-for="alertTask in alertsTasks" v-bind:key="alertTask.taskId" class="alert">
       <img src="../assets/checkicon.png" /> Reminder! It's time to give your {{name(alertTask.plantId)}} {{alertTask.taskCategory}}!
       
    </div>
  </div>
</template>

<script>
import eventService from "../services/EventService.js"
import PlantService from '../services/PlantService.js';
import TaskService from "../services/TaskService.js"

export default {
  data() {
    return {
      alertsEvents : []
      ,
      alertsTasks: []
      ,
      futureEvents: []
      ,
      myGarden: []
    };

  },
  name: "NotificationDisplay",
  methods: {
    ackAlertEvent(alertEvent){
      document.getElementById(alertEvent).classList.add("closealert");
      setTimeout(()=>{
      this.alertsEvents = this.alertsEvents.filter(e=> e != alertEvent) //update client list of alerts
      },500)
      //todo PUT to server to acknowledge event 
      //refresh future events 
    },
    ackAlertTask(taskId){
      document.getElementById(taskId).classList.add("closealert");
      setTimeout(()=>{
      
      const now = new Date();
      let ackObj = {"taskId": taskId, "userId": this.$store.state.user.userId, "lastAck": now }
      TaskService.ackTaskReminder(ackObj).then(()=>
        this.getTaskAlerts() //refresh alerts
    )},1700)
      //this.alertsTasks = this.alertsTasks.filter(e=> e.taskId != taskId); //update client list of alerts
    },
    getTaskAlerts(){
      TaskService.getTaskRemindersByUser(this.$store.state.user.userId).then(response=>{
        this.alertsTasks = response.data;
        PlantService.listGardenPlants(this.$store.state.user.userId).then(response=>{
            this.myGarden = response.data;
        
    }
      ).catch(error=>
        console.log(error.message)
      )
    }
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
    getMyGarden(){
      PlantService.listGardenPlants(this.$store.state.user.userId).then(response=>{
        this.myGarden = response.data;
        this.alertsTasks.forEach(alert=> {
      alert.commonName = this.myGarden.find(p=> p.plantId == alert.plantId).commonName
      }
    )
    }
      ).catch(error=>
        console.log(error.message)
      )
    },
    name(id){
      return this.myGarden.find(p=> p.plantId == id).commonName
    }
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
    this.getTaskAlerts()
   
    
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
  right: 7%;
  max-width: 40%;
  flex-direction: row;
  justify-content: flex-start;
  flex-wrap: wrap;
  border-style: solid;
  
  padding: 15px;
  box-shadow: 5px 10px darkslategray;
  border-radius: 30px;
  background-color: rgba(192, 211, 228, 0.308);
  border-color: rgb(131, 144, 155);
  animation-name: opencontainer;
  animation-duration: 4s;
}
.alert {
  min-width: 51%;
  margin-top: 5%;
  margin-bottom: 1%;
  border-style: solid;
  padding: 5px;
  box-shadow: 2px 2px slategrey;
  border-radius: 10px;
  background-color: #85b488ec;
  animation-name: openalerts;
  animation-duration: 6s;
}
.containertitle{
  font-family:Cambria, Cochin, Georgia, Times, 'Times New Roman', serif;
  font-size: 17pt;
  min-width: 40%;
  text-align: center;
  margin-left: auto; margin-right: auto;
  animation-name: openalerts;
  animation-duration: 4s;
}
.closealert{
  animation-name: closealert;
  animation-duration: 4s;
  animation-fill-mode: forwards;
}

@keyframes opencontainer {
  0% {width:0; height: 75px;
  }
  50% {}
  75% {height: 60%;}
  100%{width: 45% ; height: auto;}
}
@keyframes openalerts {
  0% {visibility: hidden;
  display: none; max-height: 50px;
      }
  25% { visibility: hidden;
  display: none;}
  50% {visibility: hidden;
  display: none;
  }
  75% {display: flex;max-height: 50px; }

  100% {height: auto;}
}
@keyframes closealert {
  0% {opacity: 1}
  50% {opacity: 0 ;}
  100% {display: none}
}
</style>