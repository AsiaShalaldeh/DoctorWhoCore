﻿namespace DoctorWho.DB
{
    public class EpisodeEnemy
    {
        public int EpisodeId { get; set; }
        public Episode Episode { get; set; }
        public int EnemyId { get; set; }
        public Enemy Enemy { get; set; }
    }
}
