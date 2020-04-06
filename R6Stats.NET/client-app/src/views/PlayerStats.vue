<template>
<div id="playerStats">
  <div id="nav" align="left" >
    <router-link :to="{ name: 'Home' }"><h1>R6Stats.NET</h1></router-link>
  </div>
  <playerData :data="result"></playerData>
</div>
</template>

<script lang="ts">
import { Component, Vue, Prop, Provide } from "vue-property-decorator";
import PlayerData from "../components/PlayerData.vue";

@Component({
  components: {
    PlayerData
  }
})

export default class PlayerStats extends Vue {
  @Provide() result = [];
  @Prop() loading = false;
  
  async created() {
    this.loading = true;
    this.result = [];
    await Vue.axios
      .get(`https://localhost:5001/r6stats/player/${this.$route.params.id}`)
      .then((response) =>
      {
        this.loading=false;
        this.result = response.data;
      });
  }
}
</script>