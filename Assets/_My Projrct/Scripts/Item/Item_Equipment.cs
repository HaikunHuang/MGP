using UnityEngine;
using System.Collections;

public class Item_Equipment : Item
{
	// 9	10	11	12	13	14	15	16	17	18	19	20	21	22	23	24	25	26	27	28
	// 力量	智力	敏捷	生命值	物理攻击力	魔法攻击力	
	public int power =0;
	public int wis = 0;
	public int agi = 0;
	public int HP = 0;
	public int attack = 0;
	public int magic = 0;
	// 物理防御	魔法防御	物理暴击	魔法暴击	物理穿透	
	public int anti_attack = 0;
	public int anti_magic = 0;
	public int attack_crit = 0;
	public int magic_crit = 0;
	public int attack_ap = 0;
	// 魔法穿透	吸血	物理反伤	命中	闪避	生命回复量	
	public int magic_ap = 0;
	public int vampire = 0;
	public int attack_back = 0;
	public int hit = 0;
	public int dodge = 0;
	public int life_restore = 0;
	// 抵抗沉默	技能提升等级	备注，使用全角符号。
	public int anti_silence = 0;
	public int skill_up = 0;
	public string comment;

	public Item_Equipment()
	{
		item_type = TYPE.Equipment;
	}

	// only show the info listed above
	public override string ToString()
	{
		string ret = "";

		if (power != 0) 		ret += ("力量：" + power + "\n");
		if (wis != 0) 			ret += ("智力：" + wis + "\n");
		if (agi != 0) 			ret += ("敏捷：" + agi + "\n");
		if (HP != 0) 			ret += ("生命值：" + HP + "\n");
		if (attack != 0) 		ret += ("物理攻击力：" + attack + "\n");
		if (magic != 0) 		ret += ("魔法攻击力：" + magic + "\n");
		if (anti_attack != 0)	ret += ("物理防御：" + anti_attack + "\n");
		if (anti_magic != 0)	ret += ("魔法防御：" + anti_magic + "\n");
		if (attack_crit != 0)	ret += ("物理暴击：" + attack_crit + "\n");
		if (magic_crit != 0)	ret += ("魔法暴击：" + magic_crit + "\n");
		if (attack_ap != 0)		ret += ("物理穿透：" + attack_ap + "\n");
		if (magic_ap != 0)		ret += ("魔法穿透：" + magic_ap + "\n");
		if (vampire != 0)		ret += ("吸血：" + vampire + "\n");
		if (attack_back != 0)	ret += ("物理反伤：" + attack_back + "\n");
		if (hit != 0)			ret += ("命中：" + hit + "\n");
		if (dodge != 0)			ret += ("闪避：" + dodge + "\n");
		if (life_restore != 0)	ret += ("生命回复量：" + life_restore + "\n");
		if (anti_silence != 0)	ret += ("抵抗沉默：" + anti_silence + "\n");
		if (skill_up != 0)		ret += ("抵抗沉默：" + skill_up + "\n");

		ret += ("\n\n");
		if (item_buy != 0)				ret += ("买入：$" + item_buy + "\n");
		if (item_sell != 0)				ret += ("卖出：$" + item_sell + "\n\n");
		if (item_buy_dollar != 0)		ret += ("钻石：$" + item_buy_dollar + "\n");

		ret += ("\n\n-- " + comment);

		return ret;

	}
}
