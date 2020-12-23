<template>
<div id="currentSeason">
  <b-card 
    title="Current Season">
    <b-row class="bg-light title">
        <b-col>CURRENT MMR</b-col>
        <b-col>CURRENT RANK</b-col>
        <b-col>MAXIMUM MMR</b-col>
        <b-col>MAXIMUM RANK</b-col>
    </b-row>
    <b-row class="bg-light data">
        <b-col class="my-auto">{{result.ranked.mmr}}</b-col>
        <b-col><img :src="require('../assets/ranks/hd-rank' + result.ranked.rank + '.svg')" :alt="result.ranked.rankName + ' logo'" width="50" height="50"></b-col>
        <b-col class="my-auto">{{result.ranked.maxMmr}}</b-col>
        <b-col><img :src="require('../assets/ranks/hd-rank' + result.ranked.maxRank + '.svg')" :alt="result.ranked.maxRankName + ' logo'" width="50" height="50"></b-col>
    </b-row>
    <br>
    <b-row class="bg-light title">
        <b-col>KILLS</b-col>
        <b-col>DEATHS</b-col>
        <b-col>K/D</b-col>
    </b-row>
    <b-row class="bg-light data">
        <b-col>{{result.ranked.kills}}</b-col>
        <b-col>{{result.ranked.deaths}}</b-col>
        <b-col>{{Number(result.ranked.kd).toFixed(2)}}</b-col>
    </b-row>
    <br>
    <b-row class="bg-light title">
        <b-col>WINS</b-col>
        <b-col>LOSSES</b-col>
        <b-col>W/L</b-col>
    </b-row>
    <b-row class="bg-light data" >
        <b-col>{{result.ranked.wins}}</b-col>
        <b-col>{{result.ranked.losses}}</b-col>
        <b-col>{{result.ranked.winLossPercentage}}</b-col>
    </b-row>
    <br>
    <b-row class="bg-light title">
        <b-col>MMR CHANGE</b-col>
    </b-row>
    <b-row class="bg-light">
        <b-col><p style="color: green" v-if="result.ranked.mmrChange > 0">+{{result.ranked.mmrChange}}</p><p style="color: red" v-if="result.ranked.mmrChange < 0">{{result.ranked.mmrChange}}</p></b-col>
    </b-row>
  </b-card>
</div>
</template>

<script lang="ts">
import { Component, Vue, Prop } from 'vue-property-decorator'

@Component
export default class CurrentSeason extends Vue {
  @Prop() data:any;

  get result() {
    return this.data;
  }
}
</script>

<style lang="scss">
.title{
  font-weight: bold;
  padding-top: 10px;
}

.data{
  padding-bottom: 10px;
}
</style>