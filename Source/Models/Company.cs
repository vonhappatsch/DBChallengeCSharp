using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("company")]
    public class Company
    {
        [Key, Required]
        public int CompanyId { get; set; }


        [Column("name"), Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Column("slug"), Required]
        [MaxLength(50)]
        public string Slug { get; set; }


        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }
    }


    [Table("acceleration")]
    public class Acceleration
    {
        [Key, Required]
        public int AccelerationId { get; set; }


        [Column("name"), Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Column("slug"), Required]
        [MaxLength(50)]
        public string Slug { get; set; }


        [ForeignKey("challengeId")]
        [Column("challenge_id"), Required]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }


        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }
    }


    [Table("candidate")]
    public class Candidate
    {
        [ForeignKey("userId")]
        [Column("user_id"), Required]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("accelerationId")]
        [Column("acceleration_id"), Required]
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }


        [ForeignKey("companyId")]
        [Column("company_id"), Required]
        public int CompanyId { get; set; }
        public Company Company { get; set; }


        [Column("status"), Required]
        public int Status { get; set; }


        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }
    }


    [Table("challenge")]
    public class Challenge
    {
        [Key, Required]
        public int ChallengeId { get; set; }


        [Column("name"), Required]
        [MaxLength(100)]
        public string Name { get; set; }


        [Column("slug"), Required]
        [MaxLength(50)]
        public string Slug { get; set; }


        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }

        public List<Submission> Submissions { get; set; }

        public List<Acceleration> Accelerations { get; set; }
    }


    [Table("submission")]
    public class Submission
    {
        [ForeignKey("userId")]
        [Column("user_id"), Required]
        public int UserId { get; set; }
        public User User { get; set; }


        [ForeignKey("challengeId")]
        [Column("challenge_id"), Required]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }


        [Column("score"), Required]
        public decimal Score { get; set; }


        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }
    }


    [Table("user")]
    public class User
    {
        [Key, Required]
        public int UserId { get; set; }


        [Column("full_name"), Required]
        [MaxLength(100)]
        public string FullName { get; set; }


        [Column("email"), Required]
        [MaxLength(100)]
        public string Email { get; set; }


        [Column("nickname"), Required]
        [MaxLength(50)]
        public string Nickname { get; set; }


        [Column("password"), Required]
        [MaxLength(255)]
        public string Password { get; set; }


        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }

        public List<Submission> Submissions { get; set; }
    }
}