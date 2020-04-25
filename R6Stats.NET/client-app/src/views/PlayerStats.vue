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
    this.result = [];
    
    const r6statsApi = Vue.axios.create({
      headers: {'X-API-KEY': process.env.VUE_APP_R6STATS_API_KEY}
    });

    await r6statsApi
      .get(`${process.env.VUE_APP_R6STATS_API_BASE_URL}/r6stats/player/${this.$route.params.id}`)
      .then((response) =>
      {
        this.result = response.data;
      });
  }
}
</script>