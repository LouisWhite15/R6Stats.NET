<template>
  <div class="playerData" >
    <div v-if="result.found === false">
      An error occured.
    </div>
    <br>
    <b-container> 
      <img :src="'https://ubisoft-avatars.akamaized.net/' + result.player.id + '/default_256_256.png'" width="100" height="100">
      <h3>{{result.player.name}}</h3>
      <b-row>
        <b-col>CURRENT MMR</b-col>
        <b-col>CURRENT RANK</b-col>
        <b-col>MAXIMUM MMR</b-col>
        <b-col>MAXIMUM RANK</b-col>
      </b-row>
      <b-row>
        <b-col>{{result.ranked.asiaMmr}}</b-col>
        <b-col>{{result.ranked.asiaRankName}}</b-col>
        <b-col>{{result.ranked.asiaMaxMmr}}</b-col>
        <b-col>{{result.ranked.asiaMaxRankName}}</b-col>
      </b-row>
      <br>
      <b-row>
        <b-col>KILLS</b-col>
        <b-col>DEATHS</b-col>
        <b-col>K/D</b-col>
      </b-row>
      <b-row>
        <b-col>{{result.ranked.asiaKills}}</b-col>
        <b-col>{{result.ranked.asiaDeaths}}</b-col>
        <b-col>{{result.ranked.asiaKd}}</b-col>
      </b-row>
      <br>
      <b-row>
        <b-col>WINS</b-col>
        <b-col>LOSSES</b-col>
        <b-col>W/L</b-col>
      </b-row>
      <b-row>
        <b-col>{{result.ranked.asiaWins}}</b-col>
        <b-col>{{result.ranked.asiaLosses}}</b-col>
        <b-col>{{result.ranked.asiaWinLossPercentage}}</b-col>
      </b-row>
      <br>
      <b-row>
        <b-col>MMR CHANGE</b-col>
      </b-row>
      <b-row>
        <b-col><p v-if="result.ranked.asiaMmrChange > 0">+{{result.ranked.asiaMmrChange}}</p><p v-if="result.ranked.asiaMmrChange < 0">+{{result.ranked.asiaMmrChange}}</p></b-col>
      </b-row>
    </b-container>
  </div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class PlayerData extends Vue {
  @Prop() data:any;

  get result() {
    return this.data;
  }
}
</script>