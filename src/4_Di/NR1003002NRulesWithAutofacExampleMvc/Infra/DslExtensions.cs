using System;
using System.Linq.Expressions;
using NRules.Fluent.Dsl;

namespace NR1003002NRulesWithAutofacExampleMvc.Infra
{
    //public static class DslExtensions
    //{
    //    public static ILeftHandSideExpression Claim(this ILeftHandSideExpression lhs, 
    //        Expression<Func<Claim>> alias, params Expression<Func<Claim, bool>>[] conditions)
    //    {
    //        return lhs.Match(alias, conditions);
    //    }

    //    public static ILeftHandSideExpression Patient(this ILeftHandSideExpression lhs, Expression<Func<Patient>> alias, params Expression<Func<Patient, bool>>[] conditions)
    //    {
    //        return lhs.Match(alias, conditions);
    //    }

    //    public static ILeftHandSideExpression Patient(this ILeftHandSideExpression lhs, params Expression<Func<Patient, bool>>[] conditions)
    //    {
    //        return lhs.Match(conditions);
    //    }

    //    public static ILeftHandSideExpression Insured(this ILeftHandSideExpression lhs, Expression<Func<Insured>> alias, params Expression<Func<Insured, bool>>[] conditions)
    //    {
    //        return lhs.Match(alias, conditions);
    //    }

    //    public static ILeftHandSideExpression Insured(this ILeftHandSideExpression lhs, params Expression<Func<Insured, bool>>[] conditions)
    //    {
    //        return lhs.Match(conditions);
    //    }

    //    public static IRightHandSideExpression Info(this IRightHandSideExpression rhs, Claim claim, string message)
    //    {
    //        return rhs.Do(ctx => ctx.Info(claim, message));
    //    }

    //    public static IRightHandSideExpression Warning(this IRightHandSideExpression rhs, Claim claim, string message)
    //    {
    //        return rhs.Do(ctx => ctx.Warning(claim, message));
    //    }

    //    public static IRightHandSideExpression Error(this IRightHandSideExpression rhs, Claim claim, string message)
    //    {
    //        return rhs.Do(ctx => ctx.Error(claim, message));
    //    }
    //}

    //public class Claim
    //{
    //    public virtual long Id { get; set; }
    //    public virtual ClaimType ClaimType { get; set; }
    //    public virtual ClaimStatus Status { get; set; }
    //    public virtual IList<ClaimAlert> Alerts { get; set; }
    //    public virtual Patient Patient { get; set; }
    //    public virtual Insured Insured { get; set; }

    //    public virtual bool Open => Status == ClaimStatus.Open;
    //}

}